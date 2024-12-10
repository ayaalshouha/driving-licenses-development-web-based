import { Injectable } from '@angular/core';
import { DRIVER_API_ENDPOINT } from '../environments/endpoints/driver.endpoints';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Driver } from '../models/driver.model';
@Injectable({
  providedIn: 'root',
})
export class DriverService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<Driver[]> {
    return this.http.get<Driver[]>(DRIVER_API_ENDPOINT.all);
  }
}
