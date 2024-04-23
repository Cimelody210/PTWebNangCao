using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;
namespace EntityController.Core
{
	public abstract class Base
	{
		public EF db;
		public Base()
		{
			db = new EF();
		}
	}
}