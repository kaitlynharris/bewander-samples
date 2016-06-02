@foreach (var item in Model.Avatar)
     {
         var imageID = item.FileID;
         var imageURL = "data:" + item.ContentType + ";base64," + Convert.ToBase64String(item.Content);
         if (Model.Avatar.IndexOf(item) == 0)
         {
             <div class="item active">
                 <img src="@imageURL" id="@imageID" alt="@item.FileName">
                 <p style="text-align:center">@Html.ActionLink("Delete", "DeleteImage", "UserProfiles", new { id = imageID, userID = Model.User.UserID }, null)</p>
             </div>
         }
         else
         {
             <div class="item">
                 <img src="@imageURL" id="@imageID" alt="@item.FileName">
                 <p style="text-align:center">@Html.ActionLink("Delete", "DeleteImage", "UserProfiles", new { id = imageID, userID = Model.User.UserID }, null)</p>
             </div>
         }
     }

public ActionResult DeleteImage(int id, string userID)
    {
       File file = db.Files.Find(id);
       db.Files.Remove(file);
       db.SaveChanges();
       return RedirectToAction("ProfilePage", new { userID = userID });
    }
