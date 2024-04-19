const sgMail = require('@sendgrid/mail')

const API_KEY = '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';

sgMail.setApiKey(API_KEY)

const bookTitle = "Test Book";
const renter = "Test Renter";

const message = {
    to: 'kadancer03@gmail.com',
    from: 'personalbooklibrarydesign@gmail.com',
    subject: 'Your book is overdue!',
    text: 'Dear borrower,\n\nThis is to inform you that your book ' + bookTitle + ' rented from ' + renter + ' is overdue.\nPlease return it as soon as possible.\n\nThank you,\nPersonal Book Library',
    html: '<p><strong>Dear borrower,</strong></p><p>This is to inform you that your book <strong>' + bookTitle + '</strong> rented from <strong>' + renter + '</strong> is overdue.</p><p>Please return it as soon as possible.</p><p>Thank you,<br>Personal Book Library</p>',
};

sgMail
    .send(message)
    .then(Response => console.log('Email sent.'))
    .catch(error => console.log(error.message));