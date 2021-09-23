using System;

namespace Bank.LockDown
{
    public class LockDownManager : ILockDownManager
    {
        public event EventHandler LockDownStarted;

		public event EventHandler LockDownEnded;

        private bool _isLocked = false;

		public void StartLockDown()
        {
            if(!_isLocked)
            {
                OnLockDownStarted();
                _isLocked = true;
            }
            
        }

		public void EndLockDown()
        {
             if(_isLocked)
            {
                OnLockDownEnded();
                _isLocked = false;
            }
            
        }

        protected virtual void OnLockDownStarted()
        {
            LockDownStarted?.Invoke(this, EventArgs.Empty); 
            //if (LockDownStarted != null) LockDownStarted(this, EventArgs.Empty); //les 2 lignes font la même chose
        }

        protected virtual void OnLockDownEnded()
        {
            LockDownEnded?.Invoke(this, EventArgs.Empty); 
        }
    }
}