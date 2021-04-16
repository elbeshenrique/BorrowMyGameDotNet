var initialUserQuery = db.Users.find({ "Email": "elbesh@gmail.com" });

if (initialUserQuery.count() == 0) {
    db.Users.insert({
        "_id": ObjectId(),
        "Email": "elbesh@gmail.com",
        "Password": "secret",
        "Role": "Admin"
    });
    db.Users.insert({
        "_id": ObjectId(),
        "Email": "user@gmail.com",
        "Password": "secret",
        "Role": "User"
    });
}