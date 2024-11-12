using AutoMapper;
using BeautyShopBL.Users.Entity;
using BeautyShopBL.Users.Exceptions;
using BeautyShopDataAccess.Entities;
using DataAccess.Repository;

namespace BeautyShopBL.Users.Provider;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;
    public UsersProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public IEnumerable<UserModel> GetUsers(UserFilterModel filter = null)
    {
        string? namePart = filter?.UsernamePart;
        string? emailPart = filter?.EmailPart;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? role = filter?.Role;
        var users = _userRepository.GetAll(u =>
            (namePart == null || u.Username.Contains(namePart)) &&
            (emailPart == null || u.Email.Contains(emailPart)) &&
            (creationTime == null || u.CreationTime == creationTime) &&
            (modificationTime == null || u.ModificationTime == modificationTime) &&
            (role == null || u.Role == role)
        );
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
    public UserModel GerUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new UserNotFoundException("User not found");
        }
        return _mapper.Map<UserModel>(entity);
    }
}