using System.Collections;
using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
	public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<IProcessOneRequest> GetEnumerator()
		{
			yield return new RequestCommand(x => true, new ViewAModel<ViewProductsInDepartmentRequest, IEnumerable<Product>>(new StubDisplayEngine(), input => input.products));
			yield return new RequestCommand(x => true, new ViewAModel<ViewSubDepartmentsRequest, IEnumerable<Department>>(new StubDisplayEngine(), input => input.departments ));
			yield return new RequestCommand(x => true, new ViewAModel<ViewMainDepartmentRequest, Department>(new StubDisplayEngine(), input => input.department));
		}
	}
}