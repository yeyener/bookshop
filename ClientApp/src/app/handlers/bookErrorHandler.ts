import { ErrorHandler, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

export class BookErrorHandler implements ErrorHandler {

    handleError(error: HttpErrorResponse): void {

        console.log('BookErrorHandler.handleError called');
        let messagge = '';

        if (error !== null && error.message !== null) {
            messagge += error.message;
        } else {
            messagge += 'Main error contains no information';
        }
        messagge += '\nDETAILS:\n';

        if (error.error !== null) {
            messagge += error.error;
        }

        alert(messagge);
        console.log(messagge);
        // throw error;
   }
}
