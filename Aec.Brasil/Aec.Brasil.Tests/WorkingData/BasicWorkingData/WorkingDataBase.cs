using Aec.Brasil.Tests.Interface;

namespace Aec.Brasil.Tests.WorkingData
{
	public class WorkingDataBase : IDataContainer
	{
		private static bool executou;

		public WorkingDataBase()
		{
			MontarDadosParaTeste();
		}

		private void MontarDadosParaTeste()
		{
			if (!executou)
			{
                CidadeWorkingData.Create();
				ClimaWorkingData.Create();

				executou = true;
			}
		}
	}
}
