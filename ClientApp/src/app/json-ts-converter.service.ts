import { Injectable } from '@angular/core';
import {JsonConvert, OperationMode, ValueCheckingMode} from 'json2typescript';


@Injectable()
export class JsonTsConverterService {

  constructor() { }

  convert<T>(jsonObject, classRef: any ): T {
    const jsonConvert: JsonConvert = new JsonConvert();
    jsonConvert.operationMode = OperationMode.LOGGING; // print some debug data
    jsonConvert.ignorePrimitiveChecks = false; // don't allow assigning number to string etc.
    jsonConvert.valueCheckingMode = ValueCheckingMode.DISALLOW_NULL; // never allow null

    let bi: T;
    try {
        bi = jsonConvert.deserialize(jsonObject, classRef );
    } catch (e) {
        console.log((<Error>e));
    }
    return bi;
  }

}
