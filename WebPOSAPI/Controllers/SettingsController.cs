using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly AppDBContext _context;
        public SettingsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<SettingVM>> GetSetting(string key)
        {
            var setting = await _context.Settings
                .FirstOrDefaultAsync(s => s.KeyName == key);

            if (setting == null)
                return NotFound();

            var vm = new SettingVM
            {
                Key = setting.KeyName,
                Value = setting.KeyValue
            };

            return Ok(vm);  // returns JSON object, not just string
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSetting([FromBody] SettingVM setting)
        {
            var existing = await _context.Settings.FirstOrDefaultAsync(s => s.KeyName == setting.Key);
            if (existing != null)
            {
                existing.KeyValue = setting.Value;
                _context.Settings.Update(existing);
            }
            else
            {
                _context.Settings.Add(new Settings
                {
                    KeyName = setting.Key,
                    KeyValue = setting.Value
                });
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
