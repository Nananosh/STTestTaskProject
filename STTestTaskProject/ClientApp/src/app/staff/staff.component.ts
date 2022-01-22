import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Staff} from "../../models/Staff";
import {Department} from "../../models/Department";
import {Position} from "../../models/Position";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './staff.component.html',
})
export class StaffComponent {
  public staffs: Staff[];
  public editStaff: Staff = new Staff();
  public departments: Department[];
  public positions: Position[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private router: Router, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.http.get<Staff[]>(this.baseUrl + 'staff').subscribe(result => {
      this.staffs = result;
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
        this.http.delete(this.baseUrl + 'staff/' + id).subscribe((res) => {
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

  public manageStaff(staff: Staff): void {
    if (staff.id) {
      this.http.put<any>(this.baseUrl + 'staff/' + staff.id, staff).subscribe((res) => {
        this.ngOnInit();
      })
    } else {
      this.http.post<any>(this.baseUrl + 'staff/', staff).subscribe((res) => {
        this.ngOnInit();
      })
    }
  }

  open(content, id: number) {
    this.http.get<Department[]>(this.baseUrl + 'department').subscribe(result => {
      this.departments = result;
    }, error => console.error(error));
    this.http.get<Position[]>(this.baseUrl + 'position').subscribe(result => {
      this.positions = result;
    }, error => console.error(error));
    if (id) {
      this.http.get<Staff>(this.baseUrl + 'staff/' + id).subscribe(result => {
        this.editStaff = result;
      }, error => console.error(error));
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.editStaff = new Staff();
    }, (reason) => {
      this.editStaff = new Staff();
    });
  }

}

