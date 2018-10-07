import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';
import { BookdefService } from '../../services/bookdef.service';
import { MiscService } from '../../services/misc.service';

@Component({
  selector: 'app-book-inst',
  templateUrl: './book-inst.component.html',
  styleUrls: ['./book-inst.component.css']
})
export class BookInstComponent implements OnInit {

  writersAsKvps : any = [];
  bookDefsAsKvps : any = [];
  publishersAsKvps : any = [];
  languagesAsKvps : any = [];
  translatorsAsKvps : any = [];

  writersLoaded: Promise<boolean>;
  bookDefsLoaded: Promise<boolean>;
  publishersLoaded: Promise<boolean>;
  languagesLoaded: Promise<boolean>;
  translatorsLoaded: Promise<boolean>;

  selectedWriterId : any;

  constructor(private writerService : WriterService,private bookdefService : BookdefService, private miscService : MiscService ) { }

  ngOnInit() {
     this.writerService.getAllNamesAndIds().subscribe(a => {
      this.writersAsKvps =a;
      this.writersLoaded = Promise.resolve(true);          
    });

    this.miscService.getLanguages().subscribe(a => {this.languagesAsKvps = a; this.languagesLoaded = Promise.resolve(true); });
    this.miscService.getTranslators().subscribe(a => { this.translatorsAsKvps = a; this.translatorsLoaded = Promise.resolve(true); });
    this.miscService.getPublishers().subscribe(a => { this.publishersAsKvps = a;this.publishersLoaded = Promise.resolve(true); });
  }

  onSelectWriter(selectedWriter :any){
    this.selectedWriterId = selectedWriter.key;    
    this.bookdefService.getWritersBookDefsAsKvps(this.selectedWriterId).subscribe(a =>{
      this.bookDefsAsKvps = a;
      this.bookDefsLoaded = Promise.resolve(true);
    });
  }

  onSelectBookDef(){
    

  }

}
