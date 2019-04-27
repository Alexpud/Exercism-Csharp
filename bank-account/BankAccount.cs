using System;
using System.Threading;

public class BankAccount
{
    private double balance;
    private bool isClosed = false;
    private int isLocked;
    private readonly Object lockObj = new Object();

    public void Open()
    {
        isClosed = false;
    }

    public void Close()
    {
        if (isClosed)
        {
            throw new InvalidOperationException("Cant execute operations on a closed account");
        }
        isClosed = true;
    }

    public decimal Balance
    {
        get
        {
            if (isClosed)
            {
                throw new InvalidOperationException("Cant execute operations on a closed account");
            }
            return Convert.ToDecimal(balance);
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
