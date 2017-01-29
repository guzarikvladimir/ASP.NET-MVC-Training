using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCPL.Models;

namespace MVCPL.Infrastructure
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
        public SelectList PageSizes { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public class UserFilterInfo
    {
        public SelectList Roles { get; set; }
        public string SelectedRole { get; set; }
        public string Name { get; set; }

        public UserFilterInfo(List<string> roles, string role, string name = null)
        {
            roles.Insert(0, "All");
            Roles = new SelectList(roles, role);
            SelectedRole = role;
            Name = name;
        }
    }

    public class UserSortInfo
    {
        public SortState NameSort { get; set; }
        public SortState DateSort { get; set; }
        public SortState Current { get; set; }

        public UserSortInfo(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            Current = sortOrder;
        }
    }

    public class UserPagedData
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
        public UserFilterInfo FilterInfo { get; set; }
        public UserSortInfo SortInfo { get; set; }
    }

    public class TaskPagedData
    {
        public IEnumerable<TaskViewModel> Tasks { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class ExceptionPagedData
    {
        public IEnumerable<ExceptionViewModel> Exceptions { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public enum SortState
    {
        NameAsc,
        NameDesc,
        DateAsc,
        DateDesc
    }
}