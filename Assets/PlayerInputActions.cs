//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""02f294a1-8d54-41d2-b66b-08720b734157"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""35ad459c-6f87-46e1-b321-9092908d81be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""73f54522-746e-4ab3-b9a9-89e7e5bf7039"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""044e43f3-4394-4766-a4d2-f2b6ce501226"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crawl"",
                    ""type"": ""Button"",
                    ""id"": ""ac58acdd-48e2-4f83-9c9e-636a9092918c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StandUp"",
                    ""type"": ""Button"",
                    ""id"": ""5971f864-8f58-4066-a158-e254d59347d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""97eb1aea-0296-4337-b228-3455b805f11b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AimUpCorner"",
                    ""type"": ""Button"",
                    ""id"": ""d8f7da5a-ca2b-4f75-bb44-96c8302a3d2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimUp"",
                    ""type"": ""Value"",
                    ""id"": ""09ad6423-e153-47da-b6ce-5c657a322179"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AimDownCorner"",
                    ""type"": ""Button"",
                    ""id"": ""d30b3067-611b-453b-9c54-5b1b80f50b79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimDown"",
                    ""type"": ""Value"",
                    ""id"": ""8fc8e411-9196-4423-9164-74bd732c2a56"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TurretMode"",
                    ""type"": ""Button"",
                    ""id"": ""7f4eefa2-20de-4089-97fd-47447157fbad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6b4008d7-cf7a-4e2e-8e22-162c9f860c6e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""893dd4e6-3d8d-4049-bd7a-84f9a9db4384"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""04b57bba-dcd8-443c-9814-2a0adfd9b9aa"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1ff88770-1add-4f19-a394-416a9884d6c0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d971665e-d6e6-4d5b-9da8-a4a80a38e953"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3de93d32-4cc9-403a-b4c7-be4292834823"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""618998a2-1802-4059-a3cd-d63889ecae90"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0168f37e-e2cd-47f2-8e7e-27ba76d2e0ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa4c2364-93f1-4282-88ec-9cd00b525ecf"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d77dc9a5-71fb-4b8f-a7ca-a5a0ae45f99b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96333148-f8b7-47ca-910f-731c43acaa6a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StandUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea66c4cb-38f0-4bf6-9080-3d10b379dd85"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StandUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d3c64e5-c7b9-4335-8335-9fdb793b001c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6899d98e-05c0-43f1-aa0e-39f3d3043af5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""574a005a-8c5f-49a9-9bda-ddb8a7fc510c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""2f515b92-a3c9-4a4d-b8bc-5d0515d074cb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""560fec13-5107-4a96-910c-332bbea6737c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""67da0e94-91fd-4390-b8f5-04ad455126c4"",
                    ""path"": ""ButtonWithOneModifier(overrideModifiersNeedToBePressedFirst=true)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""85b0921a-b728-4d81-ab8d-3c8ee894db7a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""eccbece2-901e-435f-b255-74eb67525421"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""a9a37982-9ee8-48c9-b5f8-bc00023a8e01"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""05c4a83a-1054-4c12-87ee-aa903349caee"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""e3b10366-eb57-4c09-88a7-c9349ffb072f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""0da5b9fb-27c0-4662-8e82-73ae58b9cb1c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""c512c051-2cdc-4e6f-af81-4722cdd2091a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""26aacbcc-e3f6-4f29-9f95-0f07d0123be1"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUpCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c773b2b-a5d5-4fd1-b5f4-7ec5ac25a4a3"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurretMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d63883ce-d5ab-46c8-a8b0-665ef9c61200"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurretMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61297e45-5490-40a1-925d-a6ebe5434c2a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crawl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d9d7031-a0b4-4800-bfaf-194b4076aa43"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crawl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""09d6fedc-ab3c-4744-b12a-58f517f0a9e5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""24a4dc16-10ec-45b6-a615-7ff155a9c1a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""b8c9d164-a351-4402-afae-7d53f76bc518"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""68cfcb38-2153-4268-bc0d-47853727d8a1"",
                    ""path"": ""ButtonWithOneModifier(overrideModifiersNeedToBePressedFirst=true)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3e9132b0-3269-44e9-8e33-914507c5df1b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""4c92360d-7232-4b89-9c22-ed1693ed319f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""1c3db4a5-983a-43f7-bb08-d65714d9e1c3"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""7dbc7b01-cf84-43d1-b0ac-5576a24c8996"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""82e295df-557c-43ea-9f36-ae733fa70aac"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""89002800-bf85-4dc8-b13c-eef2cf695b89"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""3afe0505-3d31-4d93-8393-1443fcc035aa"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""425a55fa-a176-47da-a649-7f458336349d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownCorner"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""341fd682-0377-436d-b2ea-4866dd283e2a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f7470f-6802-4cc5-8405-95023dd6c73b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""101db578-f348-4376-8f3a-028bd327fa55"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""936bafd3-60d5-4905-b663-f3d163623280"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Weapons"",
            ""id"": ""bfef7cf0-e250-4c49-b044-526e1ff727a1"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d5e9a1ab-77cd-407c-b122-9d0ac2ec39ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a659287b-a32a-453b-9376-e37941ae2850"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
        m_Movement_Crawl = m_Movement.FindAction("Crawl", throwIfNotFound: true);
        m_Movement_StandUp = m_Movement.FindAction("StandUp", throwIfNotFound: true);
        m_Movement_Shoot = m_Movement.FindAction("Shoot", throwIfNotFound: true);
        m_Movement_AimUpCorner = m_Movement.FindAction("AimUpCorner", throwIfNotFound: true);
        m_Movement_AimUp = m_Movement.FindAction("AimUp", throwIfNotFound: true);
        m_Movement_AimDownCorner = m_Movement.FindAction("AimDownCorner", throwIfNotFound: true);
        m_Movement_AimDown = m_Movement.FindAction("AimDown", throwIfNotFound: true);
        m_Movement_TurretMode = m_Movement.FindAction("TurretMode", throwIfNotFound: true);
        // Weapons
        m_Weapons = asset.FindActionMap("Weapons", throwIfNotFound: true);
        m_Weapons_Shoot = m_Weapons.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Crouch;
    private readonly InputAction m_Movement_Crawl;
    private readonly InputAction m_Movement_StandUp;
    private readonly InputAction m_Movement_Shoot;
    private readonly InputAction m_Movement_AimUpCorner;
    private readonly InputAction m_Movement_AimUp;
    private readonly InputAction m_Movement_AimDownCorner;
    private readonly InputAction m_Movement_AimDown;
    private readonly InputAction m_Movement_TurretMode;
    public struct MovementActions
    {
        private @PlayerInputActions m_Wrapper;
        public MovementActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
        public InputAction @Crawl => m_Wrapper.m_Movement_Crawl;
        public InputAction @StandUp => m_Wrapper.m_Movement_StandUp;
        public InputAction @Shoot => m_Wrapper.m_Movement_Shoot;
        public InputAction @AimUpCorner => m_Wrapper.m_Movement_AimUpCorner;
        public InputAction @AimUp => m_Wrapper.m_Movement_AimUp;
        public InputAction @AimDownCorner => m_Wrapper.m_Movement_AimDownCorner;
        public InputAction @AimDown => m_Wrapper.m_Movement_AimDown;
        public InputAction @TurretMode => m_Wrapper.m_Movement_TurretMode;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Crawl.started += instance.OnCrawl;
            @Crawl.performed += instance.OnCrawl;
            @Crawl.canceled += instance.OnCrawl;
            @StandUp.started += instance.OnStandUp;
            @StandUp.performed += instance.OnStandUp;
            @StandUp.canceled += instance.OnStandUp;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @AimUpCorner.started += instance.OnAimUpCorner;
            @AimUpCorner.performed += instance.OnAimUpCorner;
            @AimUpCorner.canceled += instance.OnAimUpCorner;
            @AimUp.started += instance.OnAimUp;
            @AimUp.performed += instance.OnAimUp;
            @AimUp.canceled += instance.OnAimUp;
            @AimDownCorner.started += instance.OnAimDownCorner;
            @AimDownCorner.performed += instance.OnAimDownCorner;
            @AimDownCorner.canceled += instance.OnAimDownCorner;
            @AimDown.started += instance.OnAimDown;
            @AimDown.performed += instance.OnAimDown;
            @AimDown.canceled += instance.OnAimDown;
            @TurretMode.started += instance.OnTurretMode;
            @TurretMode.performed += instance.OnTurretMode;
            @TurretMode.canceled += instance.OnTurretMode;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Crawl.started -= instance.OnCrawl;
            @Crawl.performed -= instance.OnCrawl;
            @Crawl.canceled -= instance.OnCrawl;
            @StandUp.started -= instance.OnStandUp;
            @StandUp.performed -= instance.OnStandUp;
            @StandUp.canceled -= instance.OnStandUp;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @AimUpCorner.started -= instance.OnAimUpCorner;
            @AimUpCorner.performed -= instance.OnAimUpCorner;
            @AimUpCorner.canceled -= instance.OnAimUpCorner;
            @AimUp.started -= instance.OnAimUp;
            @AimUp.performed -= instance.OnAimUp;
            @AimUp.canceled -= instance.OnAimUp;
            @AimDownCorner.started -= instance.OnAimDownCorner;
            @AimDownCorner.performed -= instance.OnAimDownCorner;
            @AimDownCorner.canceled -= instance.OnAimDownCorner;
            @AimDown.started -= instance.OnAimDown;
            @AimDown.performed -= instance.OnAimDown;
            @AimDown.canceled -= instance.OnAimDown;
            @TurretMode.started -= instance.OnTurretMode;
            @TurretMode.performed -= instance.OnTurretMode;
            @TurretMode.canceled -= instance.OnTurretMode;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Weapons
    private readonly InputActionMap m_Weapons;
    private List<IWeaponsActions> m_WeaponsActionsCallbackInterfaces = new List<IWeaponsActions>();
    private readonly InputAction m_Weapons_Shoot;
    public struct WeaponsActions
    {
        private @PlayerInputActions m_Wrapper;
        public WeaponsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Weapons_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Weapons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponsActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IWeaponsActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IWeaponsActions instance)
        {
            if (m_Wrapper.m_WeaponsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponsActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponsActions @Weapons => new WeaponsActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnCrawl(InputAction.CallbackContext context);
        void OnStandUp(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAimUpCorner(InputAction.CallbackContext context);
        void OnAimUp(InputAction.CallbackContext context);
        void OnAimDownCorner(InputAction.CallbackContext context);
        void OnAimDown(InputAction.CallbackContext context);
        void OnTurretMode(InputAction.CallbackContext context);
    }
    public interface IWeaponsActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
