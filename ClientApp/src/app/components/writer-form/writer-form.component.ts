import { WriterService } from './../../services/writer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-writer-form',
  templateUrl: './writer-form.component.html',
  styleUrls: ['./writer-form.component.css']
})
export class WriterFormComponent implements OnInit {

  writers2 :any[] = [];

  constructor(private service : WriterService) { }

  ngOnInit() {
    var a = this.service.getAll().subscribe(w => this.writers2 =<[]> w);
    
    //console.log(this.writers);    
  }

  alertWriter(){
    var a = 1;
    //alert(this.writers2[0].Name);
  }

}
