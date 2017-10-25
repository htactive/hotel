using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Helpers
{
    public class PaginationHelper
    {
        /// <summary>
        /// Hàm để lấy danh sách các page cho pagination
        /// </summary>
        /// <param name="currentPage">page hiện tại, được tính bắt đầu từ 0</param>
        /// <param name="totalPage">tổng số page</param>
        /// <returns>danh sách các button trên pagination</returns>
        public static List<Pagination> GetPages(int currentPage, int totalPage)
        {
            var min = Math.Max(0, currentPage - 2);
            var max = Math.Min(totalPage - 1, min + 4);
            if (max == totalPage - 1)
            {
                min = Math.Max(0, max - 4);
            }
            var result = new List<Pagination>();
            if (min > 0)
            {
                result.Add(new Pagination()
                {
                    IsActive = false,
                    Text = "...",
                    Value = min - 1
                });
            }
            for (int i = min; i <= max; i++)
            {
                result.Add(new Pagination()
                {
                    IsActive = i == currentPage,
                    Text = (i + 1) + "",
                    Value = i
                });
            }
            if (max < totalPage - 1)
            {
                result.Add(new Pagination()
                {
                    IsActive = false,
                    Text = "...",
                    Value = max + 1
                });
            }
            return result;
        }
    }

    public class Pagination
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }
}
