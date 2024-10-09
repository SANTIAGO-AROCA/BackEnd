namespace BackEndProyecto.Triggers;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string createTriggerTransactions = @"
            CREATE TRIGGER trg_AfterInsert_Transactions
            ON Transactions
            AFTER INSERT
            AS
            BEGIN
                UPDATE BankAccounts
                //SELECT i.Amount
                //IF balance - i.Amount < 0
                    
                SET balance = balance - i.Amount
                FROM inserted i
                WHERE BankAccounts.AccountId = i.IdOriginAccount;

                UPDATE BankAccounts
                SET balance = balance + i.Amount
                FROM inserted i
                WHERE BankAccounts.AccountId = i.IdDestinationAccount;

                INSERT INTO TransactionHistory (IdOriginAccount, IdDestinationAccount, Amount, TransactionDate)
                SELECT i.IdOriginAccount, i.IdDestinationAccount, i.Amount, GETDATE()
                FROM inserted i;
            END";
        string createTriggerOrders = @"
            CREATE TRIGGER trg_AfterInsert_Order
            ON Orders
            AFTER INSERT
            AS
            BEGIN

                UPDATE Products
                SET ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus = 'No disponible')
                WHERE ProductId IN (
                SELECT od.ProductId
                FROM OrderDetails od
                JOIN Products p ON p.ProductId = od.ProductId
                JOIN inserted i ON i.OrderId = od.OrderId
                WHERE p.Stock = 0
            );

            INSERT INTO OrderHistory (OrderId, ProductId, StatusChangeDate)
            SELECT i.OrderId, od.ProductId, GETDATE()
            FROM inserted i
            JOIN OrderDetails od ON i.OrderId = od.OrderId;
    END";

        string createTriggerProductPrice = @"
    CREATE TRIGGER trg_AfterUpdate_ProductPrice
    ON Products
    AFTER UPDATE
    AS
    BEGIN
        IF UPDATE(Price)
        BEGIN
            -- Inserta el cambio de precio en el historial de precios de productos
            INSERT INTO ProductPriceHistory (ProductId, OldPrice, NewPrice, ChangeDate)
            SELECT i.ProductId, d.Price, i.Price, GETDATE()
            FROM inserted i
            JOIN deleted d ON i.ProductId = d.ProductId;
        END
    END";

        string createTriggerPayments = @"
    CREATE TRIGGER trg_AfterInsert_Payment
    ON Payments
    AFTER INSERT
    AS
    BEGIN
        -- Actualiza el estado de pago a 'Pagado'
        UPDATE Payments
        SET PaymentStatusId = (SELECT PaymentStatusId FROM PaymentStatus WHERE PaymentStatus = 'Pagado')
        WHERE PaymentId IN (SELECT PaymentId FROM inserted);

        -- Inserta los detalles en el historial de pagos
        INSERT INTO PaymentHistory (PaymentId, PaymentStatusId, StatusChangeDate)
        SELECT i.PaymentId, i.PaymentStatusId, GETDATE()
        FROM inserted i;
    END";

        string createTriggerComments = @"
    CREATE TRIGGER trg_AfterInsert_Comment
    ON Comments
    AFTER INSERT
    AS
    BEGIN
        -- Clasificación a positiva si es mayor a 3
        UPDATE Comments
        SET classification = 1  -- 1 es Positivo
        WHERE CommentId IN (SELECT CommentId FROM inserted WHERE classification > 3);

        -- Inserta los detalles en el historial de comentarios
        INSERT INTO CommentHistory (CommentId, OldClassification, NewClassification, ChangeDate)
        SELECT i.CommentId, 3, i.classification, GETDATE()
        FROM inserted i;
    END";

    }
}
