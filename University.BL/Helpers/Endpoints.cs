namespace University.BL.Helpers
{
    public class Endpoints
    {
        public static string URL_BASE { get; set; } = "https://university-api.azurewebsites.net/";

        #region Students
        public static string GET_STUDENTS { get; set; } = "api/Students/GetStudents/";
        public static string GET_STUDENT { get; set; } = "api/Students/GetStudent/";
        public static string POST_STUDENTS { get; set; } = "api/Students/";
        public static string PUT_STUDENTS { get; set; } = "api/Students/";
        public static string DELETE_STUDENTS { get; set; } = "api/Students/";
        #endregion

        public static string GET_DEPARTMENTS { get; set; } = "api/Departments/";
        public static string POST_DEPARTMENTS { get; set; } = "api/Departments/";

        public static string GET_INSTRUCTORS { get; set; } = "api/Instructors/GetInstructors";
    }
}
