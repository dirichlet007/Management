create table userinfo(
account char(6) not null check(account like '[0-9][0-9][0-9][0-9][0-9][0-9]'),
password varchar(30) not null,
username varchar(20) not null,
authority int not null,
isrem int not null,
primary key(account)
)
create table tomato(
tdnum varchar(7) not null check(tdnum like 't[0-9][0-9][0-9][0-9]'),-- ��������Ϊ������ֵ
tdname varchar(20) not null,
tdtype varchar (20) not null,
tdlenth int not null,
tdtime datetime not null,
account char(6) not null,
foreign key(account) references userinfo(account)
)
create table bills(
bnum varchar(7) not null check(bnum like 'b[0-9][0-9][0-9][0-9]'),-- ��������Ϊ������ֵ
bname varchar(20) not null,
btype varchar (20) not null,
account char(6) not null,
foreign key(account) references userinfo(account)
)