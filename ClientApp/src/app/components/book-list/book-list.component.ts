import { JsonTsConverterService } from '../../json-ts-converter.service';
import { BookErrorHandler } from './../../handlers/bookErrorHandler';
import { CommunicatorService } from './../../services/communicator.service';
import { BookInstance } from './../../pocos/bookInstance';
import { BookInstService } from './../../services/book-inst.service';
import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  private writersAsKvps: any;
  writersLoaded: Promise<boolean>;
  bookListLoaded: Promise<boolean>;
  selectedWriterId: any;
  bookInstanceList: [BookInstance];

  constructor(private writerService: WriterService, private bookInstService: BookInstService, private router: Router,
    private communicator: CommunicatorService, private errHandler: BookErrorHandler, private jsonTsConverter: JsonTsConverterService) { }

  ngOnInit() {
    this.writerService.getAllNamesAndIds().subscribe(a => {
      this.writersAsKvps = a;
      this.writersLoaded = Promise.resolve(true);
    });
  }

  onSelectWriter(selectedWriter: any) {
    this.selectedWriterId = selectedWriter.key;
    this.populateList();
  }

  private populateList() {
    const q = this.createQueryObject();
    this.bookInstService.getByCustom(q).subscribe(a => {
      const objArray = [];
      const array = <[BookInstance]>a;
      array.forEach(element => {
        const c = this.jsonTsConverter.convert(element, BookInstance);
        objArray.push(c);
      });
      this.bookInstanceList = <[BookInstance]>objArray;
      this.bookListLoaded = Promise.resolve(true);
    });
  }

  updateBookInst(bi: BookInstance ) {
    this.communicator.push(bi);
    this.router.navigate(['/bookinst-form/', {ref : 'list'}]);
  }

  deleteBookInst(bi: BookInstance) {
    this.bookInstService.delete(bi.id).subscribe(a => {
      alert('Book instance deleted');
      this.populateList();
    }, err => {this.errHandler.handleError(err); } );
  }


  private createQueryObject() {
    const qo: any = {};
    qo.writerId = this.selectedWriterId;
    return qo;
  }
}
