﻿using d = FilmApp.DAL.Entities;
using FilmAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Tools
{
    public static class Mappers
    {
        public static UserWithComment ToApiUserComment(this d.UserEntity user)
        {
            return new UserWithComment()
            {
                Id = user.Id

            };
        }
        public static UserEntity ToApi(this d.UserEntity user)
        {
            return new UserEntity()
            {
                Id = user.Id

            };
        }
        public static CompleteMovie ToAPi(this d.MovieEntity movie)
        {
            return new CompleteMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                ReleaseDate = movie.ReleaseDate,
                DirectorId = movie.DirectorId,
                ScriptWriterId = movie.DirectorId
            };
        }
        public static Casting ToApi(this d.CastingEntity casting)
        {
            return new Casting()
            {
                LastName = casting.LastName,
                FirstName = casting.FirstName,
                BirthDate = casting.BirthDate,
                Character = casting.Character
            };
        }
        public static Staff ToApi(this d.StaffEntity staff)
        {
            return new Staff()
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                BirthDate = staff.BirthDate
            };
        }
        public static d.UserEntity ToDal(this UserRegister userRegister)
        {
            return new d.UserEntity() {
                Email = userRegister.Email,
                Login = userRegister.Login,
                Password = userRegister.Password
            };
        }
        public static d.UserEntity ToDal(this UserEntity user)
        {
            return new d.UserEntity()
            {
                Email = user.Email,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,  
            };
        }
        public static d.StaffEntity ToDal(this Staff staff)
        {
            return new d.StaffEntity()
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                BirthDate = staff.BirthDate
            };
        }
        public static d.MovieEntity ToDal(this Movie movie)
        {
            return new d.MovieEntity()
            { 
            Id = movie.Id,
            Title = movie.Title,
            Synopsis = movie.Synopsis,
            DirectorId = movie.DirectorId,
            ScriptWriterId = movie.ScriptWriterId,
            ReleaseDate = movie.ReleaseDate
            };
        }

    }
}
