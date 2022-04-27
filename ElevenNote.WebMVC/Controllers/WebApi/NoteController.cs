using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.WebMVC.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/Note")]
    public class NoteController : ApiController
    {
        private bool SetStarState(int noteId, bool newState)
        {
            //Create ther service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            //Get the note
            var detail = service.GetNoteById(noteId);
            //Create the NoteEdit model instance with the new star state
            var updateNote = new NoteEdit
            {
                NoteId = detail.NoteID,
                Title = detail.Title,
                Content = detail.Content,
                IsStarred = newState
            };
            //Return a value indicating whether the update succeeded
            return service.UpdateNote(updateNote);
        }
        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
