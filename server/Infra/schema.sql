drop schema if exists fullstack cascade ;
create schema fullstack;

create table fullstack.Flower(
                                 id text not null primary key,
                                 title text not null,
                                 description text not null,
                                 isExpensive boolean not null 
);

select from fullstack.Flower;