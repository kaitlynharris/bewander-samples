// cshtml code generates link to Admin panel in dropdown if user has correct permissions
// ActionLink calls Admin function in HomeController
<ul class="dropdown-menu">
    <li>@Html.ActionLink("View Profile", "ProfilePage", "UserProfiles")</li>
    <li>@Html.ActionLink("Edit Profile", "Edit", "UserProfiles")</li>
    @if (Model.User.Permission == 1)
    { <li>@Html.ActionLink("Admin", "Admin", "Home")</li>  }
    <li role="separator" class="divider"></li>
    <li><a href="javascript:document.getElementById('logoutForm').submit()">Log Off</a></li>
</ul>

// function in HomeController generating Admin view
public ActionResult Admin()
      {
          //will return Admin panel view if user has the correct permissions
          var userID = GetUserID();
          var permission = db.Users.Where(u => u.UserID == userID).Select( u => u.Permission).FirstOrDefault();
          string apiUri = Url.HttpRouteUrl("Default", new { controller = "admin", });
          ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();
          if (permission == 1)
          {
              //Admin panel must be able to display info for users, reviews, and places
              List<User> user = db.Users.ToList();
              List<Review> reviews = db.Reviews.ToList();
              List<Place> places = db.Places.ToList();
              AdminViewModel adminViewModel = new AdminViewModel { User = user, Reviews = reviews, Places = places };

              return View(adminViewModel);
          }
          // redirects users without correct permissions
          else
          {
              return RedirectToAction("Index");
          }
      }
// AdminViewModel class used by Admin function
namespace Bewander.Models
{
    public class AdminViewModel
    {
        public List<User> User { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Place> Places { get; set; }
    }
}
