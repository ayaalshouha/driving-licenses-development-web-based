// application-types.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ApplicationType {
  id: number;
  typeName: string;
  typeFees: number;
}

@Injectable({
  providedIn: 'root',
})
export class ApplicationTypesService {
  private readonly apiUrl = 'https://api.example.com/application-types'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  getApplicationTypes(): Observable<ApplicationType[]> {
    return this.http.get<ApplicationType[]>(this.apiUrl);
  }

  getApplicationTypeById(id: number): Observable<ApplicationType> {
    return this.http.get<ApplicationType>(`${this.apiUrl}/${id}`);
  }
}
