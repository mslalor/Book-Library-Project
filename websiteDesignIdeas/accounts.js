class Account{
    constructor (username, email, password){
        this.username = username;
        this.email = email;
        this.password = password;
        this.numBooks = 0;
        this.bookList = [];
    }

    addBook(book){
        this.bookList[numBooks] = book;
        numBooks++;
    }

    checkOut(book){
        print("finish this function");
    }


}

class Book{
    constructor(title, author, isbn, status){
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.status = status;
    }

    editStatus(){
        this.status = !this.status;
    }
}



