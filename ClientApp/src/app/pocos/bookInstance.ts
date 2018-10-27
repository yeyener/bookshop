import { DecimalPipe } from '@angular/common';

export class BookInstance {
    id: number;
    writerName: string;
    bookName: string;
    definitionId: number;
    price: number;
    numberInStock: number;
    edition: number;
    publisherName: string;
    publisherId: number;
    languageName: string;
    languageId: number;
    translatorId: number;
    pageNumber: number;
    // languageName: string;

    static createEmpty() {
        const newObject = new BookInstance();
        newObject.id = -1;
        newObject.definitionId = -1;
        newObject.publisherName = '-1';
        newObject.publisherId = -1;
        newObject.languageName = '-1';
        newObject.languageId = -1;
        newObject.translatorId = null;
        newObject.price = 0;
        newObject.writerName = '';
        newObject.bookName = '';
        newObject.numberInStock = 0;
        newObject.edition = 1;
        newObject.pageNumber = 0;

        return newObject;
    }
}
