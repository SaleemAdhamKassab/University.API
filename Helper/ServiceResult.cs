﻿namespace University.API.Helper
{
	public class ServiceResult
	{
		public class ResultWithMessage
		{
			public ResultWithMessage(object data, string message)
			{
				Data = data;
				Message = message;
			}

			public Object? Data { get; set; }
			public string? Message { get; set; }
		}

		public class DataWithSize
		{
			public DataWithSize(int dataSize, object data)
			{
				DataSize = dataSize;
				Data = data;
			}

			public int DataSize { get; set; }
			public object Data { get; set; }
		}
	}
}
