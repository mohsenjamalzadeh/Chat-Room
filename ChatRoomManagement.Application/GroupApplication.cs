using _01_framework.Application;
using ChatRoomManagement.Application.Contracts.Group;
using ChatRoomManagement.Domain.GroupAgg;

namespace ChatRoomManagement.Application
{
	public class GroupApplication : IGroupApplication
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IFileUploader _fileUploader;
      
        public GroupApplication(IGroupRepository groupRepository, IFileUploader fileUploader)
		{
			_groupRepository = groupRepository;
			_fileUploader = fileUploader;
		}

		public OperationResult CreateGroup(CreateGroup command)
		{
			throw new NotImplementedException();
		}

		public OperationResult EditGroup(EditGroup command)
		{
			throw new NotImplementedException();
		}

		public Task<EditGroup> GetDetails(long groupId)
		{
			throw new NotImplementedException();
		}

		public Task<List<GroupViewModel>> GetGroups()
		{
			throw new NotImplementedException();
		}
	}
}
