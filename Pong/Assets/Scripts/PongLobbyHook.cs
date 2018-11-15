using UnityEngine;
using System.Collections;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class PongLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PongPlayerController localPlayer = gamePlayer.GetComponent<PongPlayerController>();

        localPlayer.Name = lobby.playerName;
        localPlayer.playerColor = lobby.playerColor;
    }
}
