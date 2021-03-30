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
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = null,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                IsAdmin = user.IsAdmin

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
        public static UserComment ToUserComment(this d.MovieCommentEntity comment)
        {
            return new UserComment()
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                Value = comment.Value,
                MovieTitle = comment.MovieTitle,
                MovieId = comment.MovieId,
                Created_at = comment.Created_at
            };
        }
        public static CompleteComment ToApi(this d.MovieCommentEntity comment)
        {
            return new CompleteComment()
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                Value = comment.Value,
                MovieTitle = comment.MovieTitle,
                Login = comment.Login,
                MovieId = comment.MovieId,
                UserId = comment.UserId,
                Created_at = comment.Created_at
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
                Password = userRegister.Password,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                BirthDate = userRegister.BirthDate,


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
        public static Movie ToMovie(this InsertCompleteMovie movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                DirectorId = movie.DirectorId,
                ScriptWriterId = movie.ScriptWriterId,
                ReleaseDate = movie.ReleaseDate
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
        public static d.CastingEntity ToDal(this InsertCasting casting)
        {
            return new d.CastingEntity()
            {
                MovieId = casting.MovieId,
                StaffId = casting.StaffId,
                Character = casting.Character
            };
        }
        public static d.CommentEntity ToDal(this InsertComment comment)
        {
            return new d.CommentEntity()
            {
                Title = comment.Title,
                Content = comment.Content,
                Value = comment.Value,
                MovieId = comment.MovieId,
                UserId = comment.UserId
            };
        }
        public static d.UserEntity ToDal(this DeleteUser user)
        {
            return new d.UserEntity() {
            Id = user.Id,
            Reason = user.Reason
            };
        }
        public static d.CommentEntity ToDal(this DeleteComment comment)
        {
            return new d.CommentEntity()
            {
                Id = comment.Id,
                Reason = comment.Reason
            };
        }
        public static d.CommentEntity ToDal(this UpdateComment comment)
        {
            return new d.CommentEntity()
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                Value = comment.Value
            };
        }
    }
}
