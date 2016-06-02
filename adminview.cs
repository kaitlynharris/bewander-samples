@model AdminViewModel

@{
    ViewBag.Title = "Admin";
}

<br/>
<h2>Administrative Dashboard</h2>

<ul class="nav nav-pills">
    <li class="active"><a data-toggle="pill" href="#home">Home</a></li>
    <li><a data-toggle="pill" href="#users">Users</a></li>
    <li><a data-toggle="pill" href="#reviews">Reviews</a></li>
    <li><a data-toggle="pill" href="#places">Places</a></li>
</ul>

<div class="tab-content">
    <div id="home" class="tab-pane fade in active">
        <h3>Home</h3>
        @* home tab displays totals for users, reviews, and places *@
        <div class="row">
            <div class="col-sm-4">
                <div class="well">
                    <h4>Total Users</h4>
                    <h2>@Model.User.Count</h2>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="well">
                    <h4>Total Reviews</h4>
                    <h2>@Model.Reviews.Count</h2>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="well">
                    <h4>Total Places</h4>
                    <h2>@Model.Places.Count</h2>
                </div>
            </div>
        </div>

    </div>

    <div id="users" class="tab-pane fade">
        <h3>Users</h3>
        <table class="table">
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Actions</th>
            </tr>
            @foreach (var item in Model.User)
            {
                <tr>
                    <td>@Html.DisplayFor(modelItem => item.FirstName)</td>
                    <td>@Html.DisplayFor(modelItem => item.LastName)</td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", "Users", new { id = item.UserID }, null) |
                        @Html.ActionLink("Details", "Details", "Users", new { id = item.UserID }, null) |
                        @Html.ActionLink("Delete", "Delete", "Users", new { id = item.UserID }, null)
                    </td>
                    // actions call corresponding methods in Users controller
                </tr>
            }
        </table>
    </div>

    <div id="reviews" class="tab-pane fade">
        <h3>Reviews</h3>
        <table class="table">
            <tr>
                <th>Title</th>
                <th>Body</th>
                <th>Star Rating</th>
                <th>Actions</th>
            </tr>
            @foreach (var item in Model.Reviews)
            {
                <tr>
                    <td>@Html.DisplayFor(modelItem => item.Title)</td>
                    <td>@Html.DisplayFor(modelItem => item.Body)</td>
                    <td>@Html.DisplayFor(modelItem => item.StarRating)</td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", "Reviews", new { id = item.ReviewID}, null) |
                        @Html.ActionLink("Details", "Details", "Reviews", new { id = item.ReviewID }, null) |
                        @Html.ActionLink("Delete", "Delete", "Reviews", new { id = item.ReviewID }, null)
                    </td>
                    // actions call methods in Reviews controller
                </tr>
            }
        </table>
    </div>

    <div id="places" class="tab-pane fade">
        <h3>Places</h3>
        <table class="table">
            <tr>
                <th>Name</th>
                <th>Address</th>
                <th>Postal Code</th>
                <th>Actions</th>
            </tr>
            @foreach (var item in Model.Places)
            {
                <tr>
                    <td>@Html.DisplayFor(modelItem => item.Name)</td>
                    <td>@Html.DisplayFor(modelItem => item.StreetNumber) @Html.DisplayFor(modelItem => item.Route)</td>
                    <td>@Html.DisplayFor(modelItem => item.PostalCode)</td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", "Places", new { id = item.PlaceID }, null) |
                        @Html.ActionLink("Details", "Details", "Places", new { id = item.PlaceID }, null) |
                        @Html.ActionLink("Delete", "Delete", "Places", new { id = item.PlaceID }, null)
                    </td>
                    // methods in Places controller
                </tr>
            }
        </table>
    </div>
</div>
