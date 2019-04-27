using System;
using System.Threading;

public class BankAccount
{
    private double balance;
    private bool isClosed = false;
    private readonly Object lockObj = new Object();

    public void Open()
    {
        isClosed = false;
    }

    public void Close()
    {
        ValidateOperation();
        isClosed = true;
    }

    public decimal Balance
    {
        get
        {
            ValidateOperation();
            return Convert.ToDecimal(balance);
        }
    }

    private void ValidateOperation()
    {
        if (isClosed)
        {
            throw new InvalidOperationException("Cant execute operations on a closed account");
        }
    }

    public void UpdateBalance(decimal change)
    {
        lock(lockObj)
        {
            balance += Convert.ToDouble(change);
        }
    }
}
