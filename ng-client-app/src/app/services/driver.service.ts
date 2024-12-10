import { Injectable } from '@angular/core';
import { DRIVER_API_ENDPOINT } from '../environments/endpoints/driver.endpoints';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class DriverService {
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(DRIVER_API_ENDPOINT.all);
  }
}
