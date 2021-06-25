﻿namespace MovieListingsApp.Models.UserPrivileges
{
    public class CrudUserPrivileges
    {
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}