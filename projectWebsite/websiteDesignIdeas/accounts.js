class Accounts {
  constructor() {
    this.accountsList = [];
    this.accountsNum;
  }

  newAccount(account) {
    this.accountsList[this.accountsNum] = account;
    this.accountsNum++;
    console.log("success2");
  }
}

class Account {
  constructor(username, email, password, id) {
    this.username = username;
    this.email = email;
    this.password = password;
    this.numBooks = 0;
    this.bookList = [];
    this.id = id;
  }

  addBook(book) {
    this.bookList[this.numBooks] = book;
    this.numBooks++;
  }

  checkOut(book) {
    print("finish this function");
  }
}

class Book {
  constructor(title, author, isbn, status, img) {
    this.title = title;
    this.author = author;
    this.isbn = isbn;
    this.status = status;
    this.img = img;
  }
}

function initialize() {
  // console.log("success");
  var accountList = new Accounts();
}

const { Client } = require("pg");

const client = new Client({
  user: "librarian",
  host: "your_host", //update
  database: "your_database", //update
  password: "makm18910",
  port: 5432,
});

client
  .connect()
  .then(() => console.log("Connected to PostgreSQL database"))
  .catch((err) => console.error("Connection error", err));

//Example of SQL query 
/*client
  .query("SELECT * FROM your_table")
  .then((results) => console.log(results.rows))
  .catch((err) => console.error("Query error", err))
  .finally(() => client.end());   */