using System;

namespace Legacy.ProviderProcessing
{
	public class ProductsReference
	{
		private static ProductsReference instance;

		public static ProductsReference GetInstance()
		{
			return instance ?? (instance = LoadReference());
		}
		public static ProductsReference LoadReference()
		{
			throw new NotImplementedException("������-������ ������������� �����������.");
		}

		public int? FindCodeByName(string name)
		{
			throw new NotImplementedException("������ �� ������������");
		}

		// ������ ������

	}
}