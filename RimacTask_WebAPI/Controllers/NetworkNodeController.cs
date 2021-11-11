using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RimacTask.Logic;
using RimacTask.Manager;
using RimacTask.Models;
using RimacTask_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RimacTask_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkNodeController : ControllerBase
    {
        public NetworkNodeController(NetworkNodeLogic networkNodeLogic, ILogger<NetworkNodeController> logger, NetworkNodeManager networkNodeManager, SignalManager signalManager, MessagesManager messagesManager)
        {
            _logger = logger;
            _NetworkNodeManager = networkNodeManager;
            _MessagesManager = messagesManager;
            _SignalManager = signalManager;
            _Logic = networkNodeLogic;
        }

        private readonly ILogger<NetworkNodeController> _logger;
        private NetworkNodeManager _NetworkNodeManager;
        private SignalManager _SignalManager;
        private MessagesManager _MessagesManager;
        private NetworkNodeLogic _Logic;

        [HttpPost]
        [Route("CreateNetworkNode")]
        public async Task<IActionResult> CreateEntity([FromBody] NetworkNodes networkNode)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NetworkNodes, InputNetworkNode>();
                cfg.CreateMap<Signals, InputSignal>();
                cfg.CreateMap<Messages, InputMessage>();
            });
            IMapper mapper = config.CreateMapper();

            InputNetworkNode networkNodeDto = mapper.Map<NetworkNodes, InputNetworkNode>(networkNode);

            NetworkNodes newNetworkNode = new NetworkNodes()
            {
                Name = networkNode.Name,
                Messages = networkNode.Messages
            };

            await _NetworkNodeManager.CreateEntity(newNetworkNode);

            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            NetworkNodes networkNode = _NetworkNodeManager.GetById<NetworkNodes>(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NetworkNodes, InputNetworkNode>();
                cfg.CreateMap<Signals, InputSignal>();
                cfg.CreateMap<Messages, InputMessage>();
                cfg.CreateMap<IList<Messages>, List<InputMessage>>();
            });
            IMapper mapper = config.CreateMapper();

            InputNetworkNode networkNodeDto = mapper.Map<NetworkNodes, InputNetworkNode>(networkNode);

            return Ok(JsonConvert.SerializeObject(networkNodeDto));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<NetworkNodes> allRecords = _NetworkNodeManager.GetAll<NetworkNodes>();
            List<Messages> messagesRecords = _MessagesManager.GetAll<Messages>();
            List<Signals> signalsRecords = _SignalManager.GetAll<Signals>();

            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            return Ok(JsonConvert.SerializeObject(allRecords, Formatting.Indented, config));
        }

        [HttpPost]
        [Route("ParseDbcFile")]
        public IActionResult ParseDbcFile([FromBody] string filePath)
        {
            NetworkNodes networkNode = _NetworkNodeManager.ParseDbcFile<NetworkNodes>(filePath);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NetworkNodes, InputNetworkNode>();
                cfg.CreateMap<Signals, InputSignal>();
                cfg.CreateMap<Messages, InputMessage>();
            });
            IMapper mapper = config.CreateMapper();

            InputNetworkNode networkNodeDto = mapper.Map<NetworkNodes, InputNetworkNode>(networkNode);

            return Ok(JsonConvert.SerializeObject(networkNodeDto));
        }

        [HttpDelete]
        [Route("DeleteNetworkNode/{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            await _NetworkNodeManager.DeleteEntity<NetworkNodes>(id);

            return Ok();
        }
    }
}
