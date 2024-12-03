import { Injectable } from '@angular/core';
import { LICENSE_CLASS_API_ENDPOINT } from '../environments/endpoints/licenseClass.endpoint';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class LicenseClassService {
  constructor(private http: HttpClient) {}

  getAllClasses() {
    return this.http.get(LICENSE_CLASS_API_ENDPOINT.allClasses);
  }
}
