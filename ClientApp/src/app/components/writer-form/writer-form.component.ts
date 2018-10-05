import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-writer-form',
  templateUrl: './writer-form.component.html',
  styleUrls: ['./writer-form.component.css']
})
export class WriterFormComponent implements OnInit {

  writersList :any = [];

  newWriter : any = {};

  constructor(private service : WriterService) { }

  ngOnInit() {
    this.populateWriters();
  }

  populateWriters(){
    this.writersList = [];
    this.service.getAll().subscribe(w => this.writersList = w);
  }

  updateWriter(ww){
    var res = this.service.update(ww)
      .subscribe(x => {this.populateWriters();});
  }

  createWriter(ww){
    var res = this.service.create(ww)
      .subscribe(x => {this.populateWriters();});
  }

  deleteWriter(writerId, writerName){
    var conf = confirm("Are you sure you want to delete writer " + writerName + "?");
    if (conf){
      var res = this.service.delete(writerId)
              .subscribe(x => {this.populateWriters();});
      
    }
  }

  alertWriter(){
    var a = 1;
    //alert(this.writers2[0].Name);
  }

}
