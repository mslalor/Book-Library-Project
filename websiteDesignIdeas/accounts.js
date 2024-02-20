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

    checkOut(book){
        print("finish this function");
    }


}

class Book{
    constructor(title, author, isbn, status, img){
        
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.status = status;
        this.img = img; 
    }

   
}



