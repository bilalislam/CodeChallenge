using System;
using System.Data.Entity;
using Castle.DynamicProxy;
using CodeChallenge.Data.UoW;

namespace CodeChallange.Core.UoW
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly DbContext Context;
        private IInvocation _invocation;

        public UnitOfWorkInterceptor(DbContext ctx)
        {
            Context = ctx;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _invocation = invocation;

                if (UnitOfWork.Current == null)
                    UnitOfWork.Current = new UnitOfWork(Context);

                //using (UnitOfWork.Current)
                //{
                //    invocation.Proceed();
                //    UnitOfWork.Current.Commit();
                //}

                invocation.Proceed();
                UnitOfWork.Current.Commit();
            }
            catch (Exception ex)
            {
                LogManager.LogManager.Instance.DBlog.Error(Extensions.Extensions.GetAllParameters(ex, _invocation), ex);
                throw ex;
            }
            finally
            {
                UnitOfWork.Current = null;
            }
        }
    }
}
