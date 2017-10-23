# Dự án Hotel portal
Dự án làm site portal cho các khách sạn vừa và nhỏ.

## Init database
Hiện tại mình có 6 Hotel.Web, để chạy được code first cần switch Default Project trong Package Manage Console sang dự án Hotel.Web01

### Lệnh đổi environment:
Qua entity framework mới, để chọn environment khi chạy update database không còn dùng cờ -environment local như trước đây nữa, thay vào đó trước khi chạy update-database, cần set biến môi trường trước, sau đó cứ thế chạy, không cần dùng cờ.
(Vào package manage console)
<p><pre>//Lệnh để đổi environment:
$env:ASPNETCORE_ENVIRONMENT="Development"</pre></p>

<p><pre>//Xem environment hiện tại:
get-childitem env:ASPNETCORE_ENVIRONMENT</pre></p>

### Lệnh add migration:
<p><pre>//Add migration:
add-migration [tenguoiadd]_[sothutu]</pre></p>
Trong đó:
- Tên người add: account của người add ví dụ: thuan
- Số thứ tự: Số thứ tự của migration do mình add format theo 6 chữ số, ví dụ: 000012

### Lệnh update database:
<p><pre>//Add migration:
update-database </pre></p>
Đối với lệnh update database, cần cẩn thận kiểm tra evironment hiện tại trước nếu không sẽ update nhầm lên database production.
<p><pre>//Xem environment hiện tại:
get-childitem env:ASPNETCORE_ENVIRONMENT</pre></p>

## Luồng code Server
(đang update)
## Luồng code Client
(đang update)


