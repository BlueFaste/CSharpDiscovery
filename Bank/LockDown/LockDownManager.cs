using System;

namespace Bank.LockDown
{
    public class LockDownManager
    {
        public event EventHandler LockDownStarted;

		public event EventHandler LockDownEnded;

		public void StartLockDown()
        {
           if(LockDownStarted != null) LockDownStarted(this, EventArgs.Empty);
           LockDownStarted?.Invoke(this, EventArgs.Empty);
        }

		public void EndLockDown()
        {

        }
    }

}