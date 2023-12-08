using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer 
{
	public class PaginatedList<T> :List<T> 
	{
		public int PageIndex {  get; set; }
		public int TotalPage {  get; set; }
		public PaginatedList(List<T> lists,int count,int pageIndex,int pageSize) { 
			PageIndex = pageIndex;
			TotalPage = (int)Math.Ceiling(count/(double)pageSize);
			AddRange(lists);
		}
		public static PaginatedList<T> Create(IEnumerable<T> source,int pageSize,int pageIndex)
		{
			var count = source.Count();
			var result = source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
			return new PaginatedList<T> (result,count,pageIndex,pageSize);
		}

	
	}
}
