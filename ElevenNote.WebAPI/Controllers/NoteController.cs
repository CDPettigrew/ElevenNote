﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        //Create
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }
        //Get All
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }
        //Post
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateNoteService();

            if (!service.CreateNote(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //Get By Id
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }
        //Put
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateNoteService();
            if (!service.UpdateNote(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();
            if (!service.DeleteNote(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
