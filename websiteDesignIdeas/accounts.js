class Accounts{
    constructor(){
        this.accountsList = [];
        this.accountsNum;
    }

    newAccount(account){
        this.accountsList[this.accountsNum] = account;
        this.accountsNum++;
        console.log("success2");
    }
}

class Account{
    constructor (username, email, password, id){
    
        this.username = username;
        this.email = email;
        this.password = password;
        this.numBooks = 0;
        this.bookList = [];
        this.id = id;
        
        
    
    }

    addBook(book){
        this.bookList[this.numBooks] = book;
        this.numBooks++;
    }

    


}

class Book{
    constructor(title, author, isbn, status, img){
        
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.status = status;
        this.img = img; 
        this.renterEmail;
        this.dateRented;
    }

    marked(email, date, weeks){
        //console.log("here");
        this.renterEmail = email;
        this.dateRented = date;
        this.weeks = weeks;
    }

   
}



function initialize(){
   // console.log("success");
    var accountList = new Accounts();
 }

function getAccount(id){
    //search through data base for matching key to login
    //replace below line with info from the database. 
    var id = id; 
    return new Account("Kaleigh", "kaleigh@gmail.com", "password", 1);
}

function getID(){
    //some how get id of whatever the user's id that logged in
    //replace belwo line. 
    return 1; 
}

function getBooks(user){
    //replace the below lines with queries to the user's book list. If empty then just return null.
    //(it should only be empty most likely if there is a new account)
    //for now this is just our tester. 
    /* I was thinking something like this. 
    for(var i = 0; i<user.numBooks){
        var title = query for title of book i 
        var author = ^
        var isbn = ^
        var status = ^
        var img = ^
        let book = new Book (title, author, isbn, status, img);
        user.addBook(book);
    }

    */
    let book1 = new Book("Harry Potter", "JK Rowling", "0000", "In Library", "img/potter7.jpeg")
    user.addBook(book1);
    let book2 = new Book("Hunger Games", "Suzanne Collins", "0001", "In Library", "img/games1.jpeg");
    user.addBook(book2);
    let book3 = new Book("I am Malala", "Malala", "0002", "In Library", "img/malala.jpeg");
    user.addBook(book3);    
}