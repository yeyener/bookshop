import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WriterService {

  private readonly apiEndPoint = "api/writers/"

  constructor(private http : HttpClient) { }

  getAll(){
    return this.http.get(this.apiEndPoint + "getAll");
  }

  delete(id){
    return this.http.delete(this.apiEndPoint + id);
  }

  update(writer){
    return this.http.put(this.apiEndPoint + writer.id , writer);
  }

  create(writer){
    return this.http.post(this.apiEndPoint + "create" ,writer);
  }

}
