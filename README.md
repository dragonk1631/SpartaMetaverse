* 필요한 패키지 - TextMeshPro, Input System

* 폴더 구성 - Assetsd의 하위 폴더에 각 게임들의 폴더를 따로 만들었습니다
          - SpartaMetaverse 폴더의 Scenes -> MainMap 이 게임의 메인씬입니다.
          
 * 구현되어 있는 필수기능

  - WASD/화살표 키로 자유 이동
  - 카메라가 플레이어를 따라가고 일정 영역이상은 벗어나지 않음
  - 타일맵의 tilemap collider2d를 이용한 상호작용
      /플레이어의 이동제한
      /플레이어의 반투명효과
      /미니게임 영역 이동처리
  - 미니게임들 간의 씬의 이동 일부 완성(TopdownShooter),
  - flappyPlane과 Stack은 메인씬에서 이동만 됩니다.(돌아오기와 점수연동 미구현)    
  
* 미구현 필수기능
  - 미니게임들 간의 씬의 이동 미완성
  - 각 미니게임들의 점수 기록
