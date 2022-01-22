import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Department} from "../../models/Department";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './department.component.html',
})
export class DepartmentComponent {
  public departments: Department[];
  public editDepartment: Department = new Department();

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private router: Router, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.http.get<Department[]>(this.baseUrl + 'department').subscribe(result => {
      this.departments = result;
    }, error => console.error(error));
  }

  public deleteStaff(id: number): void {
    Swal.fire({
      title: 'Вы уверены, что хотите удалить запись?',
      text: "Вы не сможете восстановить этот файл!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Нет, оставить!',
      confirmButtonText: 'Да, удалить!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.delete(this.baseUrl + 'department/' + id).subscribe((res) => {
          this.ngOnInit();
        });
        Swal.fire(
          'Удалено!',
          'Ваша запись удалена.',
          'success'
        )
      }
    });
  }

  public manageDepartment(department: Department): void {
    if (department.id) {
      this.http.put<any>(this.baseUrl + 'department/' + department.id, department).subscribe((res) => {
        this.ngOnInit();
      })
    } else {
      this.http.post<any>(this.baseUrl + 'department/', department).subscribe((res) => {
        this.ngOnInit();
      })
    }
  }

  open(content, id: number) {
    if (id) {
      this.http.get<Department>(this.baseUrl + 'department/' + id).subscribe(result => {
        this.editDepartment = result;
      }, error => console.error(error));
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.editDepartment = new Department();
    }, (reason) => {
      this.editDepartment = new Department();
    });
  }

}

