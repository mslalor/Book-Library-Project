import { setApiKey, send } from '/node_modules/@sendgrid/mail/index.js';

async function sendMail(envVariable, bookTitle, userName, renterEmailTo){
    const API_KEY = envVariable;

    setApiKey(API_KEY)


    const message = {
        to: renterEmailTo,
        from: 'personalbooklibrarydesign@gmail.com',
        subject: 'Your book is overdue!',
        text: 'Dear borrower,\n\nThis is to inform you that your book ' + bookTitle + ' rented from ' + userName + ' is overdue.\nPlease return it as soon as possible.\n\nThank you,\nPersonal Book Library',
        html: '<p><strong>Dear borrower,</strong></p><p>This is to inform you that your book <strong>' + bookTitle + '</strong> rented from <strong>' + userName + '</strong> is overdue.</p><p>Please return it as soon as possible.</p><p>Thank you,<br>Personal Book Library</p>',
    };

    send(message)
        .then(Response => console.log('Email sent.'))
        .catch(error => console.log(error.message));
}