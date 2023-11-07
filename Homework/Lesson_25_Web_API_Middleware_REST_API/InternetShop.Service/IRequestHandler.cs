namespace InternetShop.Service
{
    public interface IRequestHandler <in TReq, TResp>
    {
        Task<TResp> Handle(TReq request, CancellationToken token = default);
    }

    public interface IRequestHandler<TResp>
    {
        Task<TResp> Handle(CancellationToken token = default);
    }
}
