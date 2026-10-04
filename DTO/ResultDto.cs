namespace My_ERP.DTO
{
    public class ResultDto
    {
        public MetaData MetaData { get; set; }
        public dynamic content { get; set; }

        public ResultDto()
        {
            MetaData = new MetaData();
        }

    }

    public class MetaData
    {
        public MetaData()
        {
           Currentpage = 1;
           ItemsPerPage = 10;
        }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPages { get; set; }
        public int Currentpage { get; set; }
    }
}
